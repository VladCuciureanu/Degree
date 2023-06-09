"use client";
import { createAccount, getAuthToken } from "@/libs/auth";
import { UserDto } from "@/types/user";
import { parseJwt } from "@/utils/parse-jwt";
import { ReactNode, createContext, useEffect, useState } from "react";

type AuthContextValue = {
  user: UserDto | null;
  login: (username: string, password: string) => Promise<boolean>;
  logOut: () => void;
  register: (username: string, password: string) => Promise<boolean>;
};

export const AuthContext = createContext<AuthContextValue>({} as any);

export default function AuthProvider(props: { children: ReactNode }) {
  const [user, setUser] = useState<UserDto | null>(null);

  const login = async (username: string, password: string) => {
    return getAuthToken(username, password)
      .then((res) => {
        localStorage.setItem("token", res.token);
        parseUser();
        return true;
      })
      .catch(() => {
        parseUser();
        return false;
      });
  };

  const register = async (username: string, password: string) => {
    return createAccount(username, password)
      .then(() => {
        return true;
      })
      .catch(() => {
        return false;
      });
  };

  const logOut = async () => {
    localStorage.removeItem("token");
    parseUser();
  };

  const parseUser = () => {
    let user: UserDto | null = null;

    if (typeof window !== "undefined") {
      const token = localStorage.getItem("token");
      if (token) {
        const parsedToken = parseJwt(token);
        const parsedUser: UserDto = {
          username:
            parsedToken[
              "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"
            ],
        };
        user = parsedUser;
      }
    }

    setUser(user);
  };

  useEffect(() => {
    parseUser();
  }, []);

  return (
    <AuthContext.Provider
      value={{
        user,
        login,
        logOut,
        register,
      }}
    >
      {props.children}
    </AuthContext.Provider>
  );
}

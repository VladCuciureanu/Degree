"use client";
import { getAuthToken } from "@/libs/auth";
import { UserDto } from "@/types/user";
import { parseJwt } from "@/utils/parse-jwt";
import { ReactNode, createContext, useEffect, useState } from "react";

type AuthContextValue = {
  user: UserDto | null;
  login: (username: string, password: string) => Promise<boolean>;
};

export const AuthContext = createContext<AuthContextValue>({} as any);

export default function AuthProvider(props: { children: ReactNode }) {
  const [user, setUser] = useState<UserDto | null>(null);

  const login = async (username: string, password: string) => {
    return getAuthToken(username, password)
      .then((res) => {
        localStorage.setItem("token", res.token);
        return true;
      })
      .catch(() => {
        return false;
      });
  };

  useEffect(() => {
    const token = localStorage.getItem("token");
    if (token) {
      const parsedToken = parseJwt(token);
      const user: UserDto = {
        username:
          parsedToken[
            "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"
          ],
      };
      setUser(user);
    }
  }, [localStorage.getItem("token")]);

  return (
    <AuthContext.Provider
      value={{
        user,
        login,
      }}
    >
      {props.children}
    </AuthContext.Provider>
  );
}

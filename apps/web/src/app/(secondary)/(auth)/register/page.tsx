"use client";
import { AuthContext } from "@/features/Providers/AuthProvider";
import { FormEvent, useContext, useState } from "react";
import styles from "../page.module.scss";
import { useRouter } from "next/navigation";
import Link from "next/link";

export default function RegisterPage() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const [message, setMessage] = useState("");
  const [isErrorMessage, setIsErrorMessage] = useState(false);

  const authContext = useContext(AuthContext);

  const router = useRouter();

  const onSubmit = (evt: FormEvent<HTMLFormElement>) => {
    evt.preventDefault();
    setIsErrorMessage(false);
    setMessage("Registering...");
    register(username, password);
  };

  const register = (username: string, password: string) => {
    authContext.register(username, password).then((res) => {
      if (res) {
        setIsErrorMessage(false);
        setMessage("Registered successfully! Logging in...");
        login(username, password);
      } else {
        setIsErrorMessage(true);
        setMessage("An error occured while registering user");
      }
    });
  };

  const login = (username: string, password: string) => {
    authContext.login(username, password).then((res) => {
      if (res) {
        setIsErrorMessage(false);
        setMessage("Registered and logged in!");
        setTimeout(() => {
          router.push("/");
        }, 2500);
      } else {
        setIsErrorMessage(true);
        setMessage("An error occured while logging in");
      }
    });
  };

  return (
    <>
      <form className={styles.AuthForm} onSubmit={onSubmit}>
        <h4 style={isErrorMessage ? { color: "red" } : { color: "black" }}>
          {message}
        </h4>
        <input
          value={username}
          onChange={(evt) => setUsername(evt.target.value)}
          placeholder="Your username here"
          required
        />
        <input
          value={password}
          onChange={(evt) => setPassword(evt.target.value)}
          placeholder="Your password here"
          type="password"
          required
        />
        <button>Register</button>
        <p className={styles.SignUpText}>
          Already have an account?
          <br />
          <Link href="/login">Sign in</Link>
        </p>
      </form>
    </>
  );
}

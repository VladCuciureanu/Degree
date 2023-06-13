"use client";
import { AuthContext } from "@/features/Providers/AuthProvider";
import { FormEvent, useContext, useState } from "react";
import styles from "../page.module.scss";
import { useRouter } from "next/navigation";
import Link from "next/link";

export default function LoginPage() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const [message, setMessage] = useState("");
  const [isErrorMessage, setIsErrorMessage] = useState(false);

  const authContext = useContext(AuthContext);

  const router = useRouter();

  const onSubmit = (evt: FormEvent<HTMLFormElement>) => {
    evt.preventDefault();
    authContext.login(username, password).then((res) => {
      if (res) {
        setIsErrorMessage(false);
        setMessage("Logged in successfully");
        setTimeout(() => {
          router.push("/");
        }, 2500);
      } else {
        setIsErrorMessage(true);
        setMessage("Invalid credentials");
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
        <button>Login</button>
        <p className={styles.SignUpText}>
          Don&apos;t have an account?
          <br />
          <Link href="/register">Sign up</Link>
        </p>
      </form>
    </>
  );
}

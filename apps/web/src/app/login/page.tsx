"use client";
import { AuthContext } from "@/components/Shared/Providers/AuthProvider";
import { FormEvent, useContext, useState } from "react";
import styles from "./page.module.scss";
import { useRouter } from "next/navigation";

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
        setMessage("Logged in!");
        setTimeout(() => {
          router.push("/");
        }, 2500);
      } else {
        setMessage("Failed to log in :(");
        setIsErrorMessage(true);
      }
    });
  };

  return (
    <>
      <h2 style={isErrorMessage ? { color: "red" } : { color: "black" }}>
        {message}
      </h2>
      <form className={styles.AuthForm} onSubmit={onSubmit}>
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
      </form>
    </>
  );
}

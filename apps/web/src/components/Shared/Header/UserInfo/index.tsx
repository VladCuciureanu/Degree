"use client";
import { MouseEvent, useContext } from "react";
import { AuthContext } from "../../Providers/AuthProvider";
import Link from "next/link";
import { useRouter } from "next/navigation";
import parentStyles from "../index.module.scss";
import styles from "./index.module.scss";

export default function HeaderUserInfo() {
  const authContext = useContext(AuthContext);
  const router = useRouter();

  if (authContext.user === null)
    return (
      <div className={styles.Container} style={{ gap: "8px" }}>
        <Link className={parentStyles.Link} href="/login">
          Login
        </Link>
        <Link className={parentStyles.Link} href="/register">
          Register
        </Link>
      </div>
    );

  const handleLogOut = (evt: MouseEvent<HTMLButtonElement>) => {
    evt.preventDefault();
    localStorage.removeItem("token");
    router.refresh();
  };

  return (
    <div className={styles.Container}>
      <p>{authContext.user.username}</p>
      <button className={parentStyles.Link} onClick={handleLogOut}>
        Log Out
      </button>
    </div>
  );
}

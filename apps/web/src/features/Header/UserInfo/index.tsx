"use client";
import { MouseEvent, useContext } from "react";
import { AuthContext } from "../../Providers/AuthProvider";
import Link from "next/link";
import { useRouter } from "next/navigation";
import linkStyles from "../Link/index.module.scss";
import styles from "./index.module.scss";

export default function HeaderUserInfo() {
  const authContext = useContext(AuthContext);

  if (authContext.user === null)
    return (
      <div className={styles.Container} style={{ gap: "8px" }}>
        <Link className={linkStyles.Link} href="/login">
          Login
        </Link>
        <Link className={linkStyles.Link} href="/register">
          Register
        </Link>
      </div>
    );

  const handleLogOut = (evt: MouseEvent<HTMLButtonElement>) => {
    evt.preventDefault();
    authContext.logOut();
  };

  return (
    <div className={styles.Container}>
      <p>{authContext.user.username}</p>
      <button className={linkStyles.Link} onClick={handleLogOut}>
        Log Out
      </button>
    </div>
  );
}

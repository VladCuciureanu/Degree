"use client";
import { MouseEvent, useContext } from "react";
import { AuthContext } from "../../Providers/AuthProvider";
import Link from "next/link";
import { useRouter } from "next/navigation";

export default function HeaderUserInfo() {
  const authContext = useContext(AuthContext);
  const router = useRouter();

  if (authContext.user === null) return <Link href="/login">Login</Link>;

  const handleLogOut = (evt: MouseEvent<HTMLButtonElement>) => {
    evt.preventDefault();
    localStorage.removeItem("token");
    router.refresh();
  };

  return (
    <div>
      {authContext.user.username}{" "}
      <button onClick={handleLogOut}>Log Out</button>
    </div>
  );
}

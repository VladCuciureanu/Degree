"use client";
import Link from "next/link";
import styles from "./index.module.scss";
import { ReactNode } from "react";
import { usePathname } from "next/navigation";

type HeaderLinkProps = {
  href: string;
  children: ReactNode;
};

export default function HeaderLink(props: HeaderLinkProps) {
  const pathname = usePathname();
  const isCurrentRoute = pathname === props.href;
  return (
    <Link
      href={props.href}
      className={isCurrentRoute ? styles.LinkHighlighted : styles.Link}
    >
      {props.children}
    </Link>
  );
}

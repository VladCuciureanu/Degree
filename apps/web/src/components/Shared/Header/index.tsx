import Link from "next/link";
import styles from "./index.module.scss";
import UserInfo from "./UserInfo";

export default function Sidebar() {
  return (
    <header className={styles.Container}>
      <nav className={styles.NavContainer}>
        <Link className={styles.Link} href="/">
          Home
        </Link>
        <Link className={styles.Link} href="/albums">
          Albums
        </Link>
        <Link className={styles.Link} href="/artists">
          Artists
        </Link>
      </nav>
      <UserInfo />
    </header>
  );
}

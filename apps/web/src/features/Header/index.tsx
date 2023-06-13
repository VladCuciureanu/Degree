import Link from "./Link";
import styles from "./index.module.scss";
import UserInfo from "./UserInfo";

export default function Sidebar() {
  return (
    <header className={styles.Container}>
      <nav className={styles.NavContainer}>
        <Link href="/">Home</Link>
        <Link href="/artists">Artists</Link>
        <Link href="/albums">Albums</Link>
      </nav>
      <UserInfo />
    </header>
  );
}

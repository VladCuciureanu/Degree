import { Song } from "@/types/song";
import styles from "./page.module.scss";

export const revalidate = 0;

async function getData() {
  const res = await fetch(`${process.env.API_URL}/api/tracks`);

  if (!res.ok) {
    // This will activate the closest `error.js` Error Boundary
    throw new Error("Failed to fetch data");
  }

  return res.json();
}

export default async function SongsPage() {
  const data: Song[] = await getData();
  return (
    <main className={styles.Container}>
      <h2>Songs</h2>
      {data.map((song) => (
        <p key={song.id}>{song.name}</p>
      ))}
    </main>
  );
}

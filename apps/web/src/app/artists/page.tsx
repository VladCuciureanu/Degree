import { ArtistDto } from "@/types/artist";
import styles from "./page.module.scss";
import Link from "next/link";
import Image from "next/image";
import { PaginatedList } from "@/types/common";

export const revalidate = 0;

async function getData() {
  const res = await fetch(`${process.env.API_URL}/api/artists`);

  if (!res.ok) {
    // This will activate the closest `error.js` Error Boundary
    throw new Error("Failed to fetch data");
  }

  return res.json();
}

export default async function ArtistsPage() {
  const data: PaginatedList<ArtistDto> = await getData();
  return (
    <main className={styles.Container}>
      <h2 className={styles.Header}>Artists</h2>
      <div className={styles.ArtistGrid}>
        {data.items.map((artist) => (
          <Link
            key={artist.id}
            href={`/artists/${artist.id}`}
            className={styles.ArtistCard}
          >
            <Image
              alt={`${artist.name}'s profile picture.`}
              src={artist.imageUrl ?? "/default_photo.png"}
              height={128}
              width={128}
              className={styles.ArtistImage}
            />
            <p className={styles.ArtistName}>{artist.name}</p>
          </Link>
        ))}
      </div>
    </main>
  );
}

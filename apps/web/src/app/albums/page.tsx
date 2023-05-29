import { AlbumDto } from "@/types/album";
import styles from "./page.module.scss";
import Link from "next/link";
import Image from "next/image";
import { PaginatedList } from "@/types/common";

export const revalidate = 0;

async function getData() {
  const res = await fetch(`${process.env.NEXT_PUBLIC_API_URL}/api/albums`);

  if (!res.ok) {
    // This will activate the closest `error.js` Error Boundary
    throw new Error("Failed to fetch data");
  }

  return res.json();
}

export default async function AlbumsPage() {
  const data: PaginatedList<AlbumDto> = await getData();
  return (
    <main className={styles.Container}>
      <h2 className={styles.Header}>Albums</h2>
      <div className={styles.AlbumGrid}>
        {data.items.map((album) => (
          <Link
            key={album.id}
            href={`/albums/${album.id}`}
            className={styles.AlbumCard}
          >
            <Image
              alt={`${album.name}'s cover art.`}
              src={album.imageUrl ?? "/default_photo.png"}
              height={128}
              width={128}
              className={styles.AlbumImage}
            />
            <p className={styles.AlbumName}>{album.name}</p>
          </Link>
        ))}
      </div>
    </main>
  );
}

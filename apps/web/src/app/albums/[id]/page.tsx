import { Album } from "@/types/album";
import styles from "./page.module.scss";
import Image from "next/image";

export const revalidate = 0;

async function getData(id: string) {
  const res = await fetch(`${process.env.API_URL}/api/albums/${id}`);

  if (!res.ok) {
    // This will activate the closest `error.js` Error Boundary
    throw new Error("Failed to fetch data");
  }

  return res.json();
}

type AlbumDetailsPageParams = {
  params: { id: string };
};

export default async function AlbumDetailsPage(props: AlbumDetailsPageParams) {
  const data: Album = await getData(props.params.id);

  return (
    <main className={styles.Container}>
      <h2>{data.name}</h2>
      <Image
        alt={`${data.name}'s cover art.`}
        src={data.imageUrl ?? "/default_photo.png"}
        height={256}
        width={256}
      />
    </main>
  );
}

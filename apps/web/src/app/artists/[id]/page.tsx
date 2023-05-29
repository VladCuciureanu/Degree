import { Artist } from "@/types/artist";
import styles from "./page.module.scss";
import Image from "next/image";

export const revalidate = 0;

async function getData(id: string) {
  const res = await fetch(`${process.env.API_URL}/api/artists/${id}`);
  console.log({ res });
  if (!res.ok) {
    // This will activate the closest `error.js` Error Boundary
    throw new Error("Failed to fetch data");
  }

  return res.json();
}

type ArtistDetailsPageParams = {
  params: { id: string };
};

export default async function ArtistDetailsPage(
  props: ArtistDetailsPageParams
) {
  const data: Artist = await getData(props.params.id);
  return (
    <main className={styles.Container}>
      <h2>{data.name}</h2>
      <Image
        alt={`${data.name}'s profile picture.`}
        src={data.imageUrl ?? "/default_photo.png"}
        height={256}
        width={256}
      />
    </main>
  );
}

import { ArtistDto } from "@/types/artist";
import styles from "./page.module.scss";
import Image from "next/image";
import { getArtist } from "@/libs/artists";

export const revalidate = 0;

type ArtistDetailsPageParams = {
  params: { id: number };
};

export default async function ArtistDetailsPage(
  props: ArtistDetailsPageParams
) {
  const data: ArtistDto = await getArtist(props.params.id);
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

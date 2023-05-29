import { AlbumDto } from "@/types/album";
import styles from "./page.module.scss";
import Image from "next/image";
import { PaginatedList } from "@/types/common";
import { TrackDto } from "@/types/track";
import Track from "@/components/Shared/Track";

export const revalidate = 0;

async function getAlbumData(id: string) {
  const res = await fetch(
    `${process.env.NEXT_PUBLIC_API_URL}/api/albums/${id}`
  );

  if (!res.ok) {
    // This will activate the closest `error.js` Error Boundary
    throw new Error("Failed to fetch data");
  }

  return res.json();
}

async function getAlbumTracksData(id: string) {
  const res = await fetch(
    `${process.env.NEXT_PUBLIC_API_URL}/api/albums/${id}/tracks`
  );

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
  const albumData: AlbumDto = await getAlbumData(props.params.id);
  const tracksData: TrackDto[] = await getAlbumTracksData(props.params.id);

  return (
    <main className={styles.Container}>
      <h2>{albumData.name}</h2>
      <Image
        alt={`${albumData.name}'s cover art.`}
        src={albumData.imageUrl ?? "/default_photo.png"}
        height={256}
        width={256}
      />
      <div>
        {tracksData.map((data) => (
          <Track key={data.id} data={data} />
        ))}
      </div>
    </main>
  );
}

import { AlbumDto } from "@/types/album";
import styles from "./page.module.scss";
import Image from "next/image";
import { TrackDto } from "@/types/track";
import Track from "@/features/Track";
import { getAlbum, getAlbumTracks } from "@/libs/albums";

export const revalidate = 0;

type AlbumDetailsPageParams = {
  params: { id: number };
};

export default async function AlbumDetailsPage(props: AlbumDetailsPageParams) {
  const albumData: AlbumDto = await getAlbum(props.params.id);
  const tracksData: TrackDto[] = await getAlbumTracks(props.params.id);

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

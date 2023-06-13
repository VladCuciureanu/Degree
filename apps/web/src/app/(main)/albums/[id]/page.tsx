import { getAlbum, getAlbumTracks } from "@/libs/albums";
import { AlbumDto } from "@/types/album";
import { TrackDto } from "@/types/track";
import TrackCard from "@/features/Track/Card";
import Image from "next/image";
import styles from "./page.module.scss";
import ArtistLink from "@/features/Artist/Link";

export const revalidate = 0;

type AlbumDetailsPageParams = {
  params: { id: number };
};

export default async function AlbumDetailsPage(props: AlbumDetailsPageParams) {
  const albumData: AlbumDto = await getAlbum(props.params.id);
  const tracksData: TrackDto[] = await getAlbumTracks(props.params.id);

  return (
    <main className={styles.Container}>
      <section className={styles.Header}>
        <Image
          alt={`${albumData.name}'s cover art.`}
          src={albumData.imageUrl ?? "/default_photo.png"}
          height={192}
          width={192}
          className={styles.CoverArt}
        />
        <div className={styles.Info}>
          <div className={styles.MetadataRow}>
            <ArtistLink data={albumData.artist} />
          </div>
          <h1 className={styles.Name}>{albumData.name}</h1>
          <p>{albumData.type}</p>
        </div>
      </section>
      <div>
        {tracksData.map((data) => (
          <TrackCard key={data.id} data={data} />
        ))}
      </div>
    </main>
  );
}

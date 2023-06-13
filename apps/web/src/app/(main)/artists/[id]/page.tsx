import { getArtist, getArtistAlbums } from "@/libs/artists";
import { ArtistDto } from "@/types/artist";
import styles from "./page.module.scss";
import Image from "next/image";
import { AlbumDto } from "@/types/album";
import AlbumCard from "@/features/Album/Card";

export const revalidate = 0;

type ArtistDetailsPageParams = {
  params: { id: number };
};

export default async function ArtistDetailsPage(
  props: ArtistDetailsPageParams
) {
  const artist: ArtistDto = await getArtist(props.params.id);
  const albums: AlbumDto[] = await getArtistAlbums(props.params.id);

  return (
    <main className={styles.Container}>
      <section className={styles.Header}>
        <Image
          alt={`${artist.name}'s cover art.`}
          src={artist.imageUrl ?? "/default_photo.png"}
          height={192}
          width={192}
          className={styles.Avatar}
        />
        <div className={styles.Info}>
          <h1 className={styles.Name}>{artist.name}</h1>
        </div>
        <div></div>
      </section>
      <h2 className={styles.Subtitle}>Albums</h2>
      {albums.map((album) => (
        <AlbumCard key={album.id} data={album} />
      ))}
    </main>
  );
}

import { ArtistDto } from "@/types/artist";
import styles from "./page.module.scss";
import { PaginatedList } from "@/types/common";
import { getArtists } from "@/libs/artists";
import ArtistCard from "@/features/Artist/Card";

export const revalidate = 0;

export default async function ArtistsPage() {
  const data: PaginatedList<ArtistDto> = await getArtists();
  return (
    <main className={styles.Container}>
      <h2 className={styles.Header}>Artists</h2>
      <div className={styles.Grid}>
        {data.items.map((data) => (
          <ArtistCard key={data.id} data={data} />
        ))}
      </div>
    </main>
  );
}

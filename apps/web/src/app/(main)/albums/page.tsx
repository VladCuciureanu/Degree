import AlbumCard from "@/features/AlbumCard";
import { getAlbums } from "@/libs/albums";
import { PaginatedList } from "@/types/common";
import { AlbumDto } from "@/types/album";
import styles from "./page.module.scss";

export const revalidate = 0;

export default async function AlbumsPage() {
  const data: PaginatedList<AlbumDto> = await getAlbums();
  return (
    <main className={styles.Container}>
      <h2 className={styles.Header}>Albums</h2>
      <div className={styles.Grid}>
        {data.items.map((data) => (
          <AlbumCard key={data.id} data={data} />
        ))}
      </div>
    </main>
  );
}

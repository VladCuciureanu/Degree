import Image from "next/image";
import Link from "next/link";
import styles from "./index.module.scss";
import { AlbumDto } from "@/types/album";

type AlbumCardProps = {
  data: AlbumDto;
};

export default function AlbumCard(props: AlbumCardProps) {
  return (
    <Link
      key={props.data.id}
      href={`/albums/${props.data.id}`}
      className={styles.Card}
    >
      <Image
        alt={`${props.data.name}'s cover art.`}
        src={props.data.imageUrl ?? "/default_photo.png"}
        height={128}
        width={128}
        className={styles.Image}
      />
      <p className={styles.Name}>{props.data.name}</p>
    </Link>
  );
}

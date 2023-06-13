import Image from "next/image";
import Link from "next/link";
import styles from "./index.module.scss";
import { ArtistDto } from "@/types/artist";

type ArtistCardProps = {
  data: ArtistDto;
};

export default function ArtistCard(props: ArtistCardProps) {
  return (
    <Link
      key={props.data.id}
      href={`/artists/${props.data.id}`}
      className={styles.Card}
    >
      <Image
        alt={`${props.data.name}'s profile picture.`}
        src={props.data.imageUrl ?? "/default_photo.png"}
        height={128}
        width={128}
        className={styles.Image}
      />
      <p className={styles.Name}>{props.data.name}</p>
    </Link>
  );
}

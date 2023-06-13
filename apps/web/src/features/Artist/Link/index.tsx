import { ArtistDto } from "@/types/artist";
import Image from "next/image";
import Link from "next/link";
import styles from "./index.module.scss";

type ArtistLinkProps = {
  data: ArtistDto;
};

export default function ArtistLink(props: ArtistLinkProps) {
  return (
    <Link href={`/artists/${props.data.id}`} className={styles.Container}>
      <Image
        src={props.data.imageUrl ?? "/default_photo.png"}
        alt={`${props.data.name}'s profile photo.`}
        height={32}
        width={32}
        className={styles.Avatar}
      />
      {props.data.name}
    </Link>
  );
}

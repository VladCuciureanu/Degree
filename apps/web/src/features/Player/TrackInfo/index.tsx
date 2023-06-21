"use client";
import { PlayerContext } from "@/features/Providers/PlayerProvider";
import { useContext } from "react";
import Image from "next/image";
import styles from "./index.module.scss";
import Link from "next/link";

export default function PlayerTrackInfo() {
  const playerContext = useContext(PlayerContext);

  return (
    <>
      <Image
        src={playerContext.album?.imageUrl ?? "/default_photo.png"}
        alt={"The album's cover art"}
        className={styles.CoverArt}
        height={128}
        width={128}
        draggable={false}
        style={
          playerContext.album
            ? undefined
            : { filter: "grayscale(100%)", opacity: 0.35 }
        }
      />
      <aside className={styles.TextContainer}>
        <p className={styles.SongTitle}>{playerContext.track?.name ?? ""}</p>
        <Link
          className={styles.ArtistName}
          href={`/artists/${playerContext.album?.artist?.id}` ?? undefined}
        >
          {playerContext.album?.artist?.name ?? ""}
        </Link>
      </aside>
    </>
  );
}

"use client";
import { useContext, useEffect, useState } from "react";
import styles from "./index.module.scss";
import { PlayerContext } from "../Providers/PlayerProvider";
import Image from "next/image";
import Link from "next/link";

export default function Player() {
  const playerContext = useContext(PlayerContext);

  const handlePlayButton = () => {
    if (playerContext.playing) {
      playerContext.pause();
    } else {
      playerContext.resume();
    }
  };

  return (
    <main id="player" className={styles.Container}>
      <section className={styles.Left}>
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
      </section>
      <section className={styles.Middle}>
        <button
          disabled={playerContext.track === null}
          onClick={handlePlayButton}
        >
          {playerContext.playing ? <>Pause</> : <>Play</>}
        </button>
      </section>
      <section className={styles.Right}>Right</section>
    </main>
  );
}

"use client";
import { useContext, useEffect, useState } from "react";
import styles from "./index.module.scss";
import { PlayerContext } from "../Providers/PlayerProvider";
import Image from "next/image";
import { AlbumDto } from "@/types/album";
import { ArtistDto } from "@/types/artist";
import Link from "next/link";

export default function Player() {
  const [album, setAlbum] = useState<AlbumDto | null>(null);
  const [artist, setArtist] = useState<ArtistDto | null>(null);

  const playerContext = useContext(PlayerContext);

  const handlePlayButton = () => {
    if (playerContext.playing) {
      playerContext.pause();
    } else {
      playerContext.resume();
    }
  };

  useEffect(() => {
    if (playerContext.track) {
      fetch(
        `${process.env.NEXT_PUBLIC_API_URL}/api/albums/${playerContext.track.albumId}`
      )
        .then((res) => {
          if (!res.ok) {
            // This will activate the closest `error.js` Error Boundary
            throw new Error("Failed to fetch data");
          }

          return res.json();
        })
        .then((res) => setAlbum(res));
    } else {
      setAlbum(null);
    }
  }, [playerContext.track]);

  useEffect(() => {
    if (album) {
      fetch(`${process.env.NEXT_PUBLIC_API_URL}/api/artists/${album.artistId}`)
        .then((res) => {
          if (!res.ok) {
            // This will activate the closest `error.js` Error Boundary
            throw new Error("Failed to fetch data");
          }

          return res.json();
        })
        .then((res) => setArtist(res));
    } else {
      setArtist(null);
    }
  }, [album]);

  return (
    <main id="player" className={styles.Container}>
      <section className={styles.Left}>
        <Image
          src={album?.imageUrl ?? "/default_photo.png"}
          alt={"The album's cover art"}
          className={styles.CoverArt}
          height={128}
          width={128}
          draggable={false}
        />
        <aside className={styles.TextContainer}>
          <p className={styles.SongTitle}>{playerContext.track?.name ?? ""}</p>
          <Link className={styles.ArtistName} href={`/artists/${artist?.id}`}>
            {artist?.name ?? ""}
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
      <section className={styles.Right}></section>
    </main>
  );
}

"use client";
import { TrackDto } from "@/types/track";
import styles from "./index.module.scss";
import { useContext, useEffect, useState } from "react";
import { PlayerContext } from "../../Player/Provider";
import { getTrackArtists } from "@/libs/tracks";
import { ArtistDto } from "@/types/artist";
import ArtistLink from "@/features/Artist/Link";
import PauseIcon from "@/assets/graphics/Pause";
import PlayIcon from "@/assets/graphics/Play";

type TrackProps = {
  data: TrackDto;
};

export default function Track(props: TrackProps) {
  const [artists, setArtists] = useState<ArtistDto[]>([]);

  const playerContext = useContext(PlayerContext);

  const isPlaying =
    playerContext.track?.id === props.data.id && playerContext.playing;

  const handlePlayButton = () => {
    if (isPlaying) {
      playerContext.pause();
    } else {
      playerContext.play(props.data.id);
    }
  };

  useEffect(() => {
    getTrackArtists(props.data.id).then((res) => setArtists(res));
  }, [props.data.id]);

  return (
    <article className={styles.Container}>
      <div className={styles.Left}>
        <p className={styles.Number}>{props.data.number}</p>
        <button id="play-button" onClick={handlePlayButton}>
          {isPlaying ? <PauseIcon /> : <PlayIcon />}
        </button>
        <section className={styles.Info}>
          <h2 className={styles.Name}>{props.data.name}</h2>
          <div className={styles.ArtistList}>
            {artists.map((artist, index) => (
              <>
                <ArtistLink key={artist.id} data={artist} hideAvatar />
                {index < artists.length - 1 && <div>{", "}</div>}
              </>
            ))}
          </div>
        </section>
      </div>
      <div className={styles.Right}>...</div>
    </article>
  );
}

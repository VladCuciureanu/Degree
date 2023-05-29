"use client";
import { TrackDto } from "@/types/track";
import styles from "./index.module.scss";

type TrackProps = {
  data: TrackDto;
};

export default function Track(props: TrackProps) {
  const isPlaying = false;

  const handlePlayButton = () => {
    if (isPlaying) {
      // pause
    } else {
      // start playing and set state
    }
  };

  return (
    <article className={styles.Container}>
      <div className={styles.Left}>
        <button id="play-button" onClick={handlePlayButton}>
          {isPlaying ? <>Pause</> : <>Play</>}
        </button>
        <p>{props.data.name}</p>
      </div>
      <div className={styles.Right}>...</div>
    </article>
  );
}

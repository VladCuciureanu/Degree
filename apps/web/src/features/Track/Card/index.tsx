"use client";
import { TrackDto } from "@/types/track";
import styles from "./index.module.scss";
import { useContext } from "react";
import { PlayerContext } from "../../Providers/PlayerProvider";

type TrackProps = {
  data: TrackDto;
};

export default function Track(props: TrackProps) {
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

  return (
    <article className={styles.Container}>
      <div className={styles.Left}>
        <button id="play-button" onClick={handlePlayButton}>
          {isPlaying ? <>Pause</> : <>Play</>}
        </button>
        <p>{props.data.name}</p>
        <audio
          controls
          src={`http://localhost:5049/api/tracks/${props.data.id}/content`}
        />
      </div>
      <div className={styles.Right}>...</div>
    </article>
  );
}

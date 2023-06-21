"use client";
import {
  LegacyRef,
  ReactEventHandler,
  useContext,
  useEffect,
  useRef,
  useState,
} from "react";
import styles from "./index.module.scss";
import { PlayerContext } from "../Providers/PlayerProvider";
import PauseIcon from "@/assets/graphics/Pause";
import PlayIcon from "@/assets/graphics/Play";
import TrackInfo from "./TrackInfo";
import VolumeWidget from "./VolumeWidget";
import GoBackIcon from "@/assets/graphics/GoBack";
import GoForwardIcon from "@/assets/graphics/GoForward";

export default function Player() {
  const playerContext = useContext(PlayerContext);

  const audioPlayer = useRef<HTMLAudioElement>();
  const progressBar = useRef<HTMLInputElement>();

  const [duration, setDuration] = useState<number>(0);
  const [progress, setProgress] = useState<number>(0);

  useEffect(() => {
    if (playerContext.playing) {
      audioPlayer.current?.play();
    } else {
      audioPlayer.current?.pause();
    }
    audioPlayer.current!.volume = playerContext.volume / 100;
  }, [playerContext.playing, playerContext.volume]);

  const togglePlayPause = () => {
    if (playerContext.playing) {
      playerContext.pause();
    } else {
      playerContext.resume();
    }
  };

  const onMetadata: ReactEventHandler<HTMLAudioElement> = (ev) => {
    setDuration(
      Number.isNaN(ev.currentTarget.duration)
        ? 100
        : Math.floor(ev.currentTarget.duration)
    );
  };

  const onTimeUpdate: ReactEventHandler<HTMLAudioElement> = (ev) => {
    setProgress(ev.currentTarget.currentTime);
  };

  const onScrub: ReactEventHandler<HTMLInputElement> = (ev) => {
    const scrubbedTimestamp = Number(ev.currentTarget.value);
    setProgress(scrubbedTimestamp);
    audioPlayer.current!.currentTime = scrubbedTimestamp;
    playerContext.resume();
  };

  const goBack = () => {
    playerContext.goToPrevious();
  };

  const goForward = () => {
    playerContext.goToNext();
  };

  const rewind = () => {
    setProgress(0);
    audioPlayer.current!.currentTime = 0;
    playerContext.resume();
  };

  return (
    <main id="player" className={styles.Container}>
      <audio
        src={`${process.env.NEXT_PUBLIC_API_URL}/api/tracks/${playerContext.track?.id}/content`}
        ref={audioPlayer as LegacyRef<HTMLAudioElement>}
        onTimeUpdate={onTimeUpdate}
        onLoadedMetadata={onMetadata}
        autoPlay
      />
      <section className={styles.Left}>
        <TrackInfo />
      </section>
      <section className={styles.Middle}>
        <section className={styles.Controls}>
          <section id="buttons">
            <button
              className={styles.IconButton}
              onClick={rewind}
              onDoubleClick={goBack}
            >
              <GoBackIcon />
            </button>
            <button
              className={styles.PlayButton}
              disabled={playerContext.track === null}
              onClick={togglePlayPause}
            >
              {playerContext.playing ? <PauseIcon /> : <PlayIcon />}
            </button>
            <button className={styles.IconButton} onClick={goForward}>
              <GoForwardIcon />
            </button>
          </section>
        </section>
        <input
          type="range"
          ref={progressBar as LegacyRef<HTMLInputElement>}
          min={0}
          className={styles.ProgressBar}
          max={duration}
          value={progress}
          onChange={onScrub}
          disabled={audioPlayer.current === undefined}
        />
      </section>
      <section className={styles.Right}>
        <VolumeWidget />
      </section>
    </main>
  );
}

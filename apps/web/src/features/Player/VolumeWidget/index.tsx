import VolumeOnIcon from "@/assets/graphics/VolumeOn";
import { PlayerContext } from "@/features/Player/Provider";
import { ChangeEvent, useContext } from "react";
import styles from "../index.module.scss";
import VolumeOffIcon from "@/assets/graphics/VolumeOff";

export default function PlayerVolumeWidget() {
  const playerContext = useContext(PlayerContext);

  const handleVolumeChange = (evt: ChangeEvent<HTMLInputElement>) => {
    playerContext.setVolume(parseInt(evt.target.value));
  };

  return (
    <>
      <button
        className={styles.IconButton}
        id="toggle-volume"
        onClick={() => playerContext.toggleMute()}
      >
        {playerContext.muted ? <VolumeOffIcon /> : <VolumeOnIcon />}
      </button>
      <input
        id="volume"
        type={"range"}
        onChange={handleVolumeChange}
        value={playerContext.volume}
        min={0}
        max={100}
      />
    </>
  );
}

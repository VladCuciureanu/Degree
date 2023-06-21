import { PlayerContext } from "@/features/Providers/PlayerProvider";
import { ChangeEvent, useContext } from "react";

export default function PlayerVolumeWidget() {
  const playerContext = useContext(PlayerContext);

  const handleVolumeChange = (evt: ChangeEvent<HTMLInputElement>) => {
    playerContext.setVolume(parseInt(evt.target.value));
  };

  return (
    <>
      <button id="toggle-volume" onClick={() => playerContext.toggleMute()}>
        {playerContext.muted ? "M" : "U"}
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

"use client";
import { TrackDto } from "@/types/track";
import { ReactNode, createContext, useState } from "react";

type PlayerContextValue = {
  playing: boolean;
  track: TrackDto | null;
  play: (trackId: number) => void;
  pause: () => void;
  resume: () => void;
  queue: TrackDto[];
  history: TrackDto[];
  goToNext: () => void;
  hasNext: boolean;
  goToPrevious: () => void;
  hasPrevious: boolean;
};

export const PlayerContext = createContext<PlayerContextValue>({} as any);

export default function PlayerProvider(props: { children: ReactNode }) {
  const [playing, setPlaying] = useState(false);
  const [track, setTrack] = useState<TrackDto | null>(null);
  const [queue, setQueue] = useState<TrackDto[]>([]);
  const [history, setHistory] = useState<TrackDto[]>([]);

  const play = (trackId: number) => {
    fetch(`${process.env.NEXT_PUBLIC_API_URL}/api/tracks/${trackId}`, {})
      .then((res) => res.json())
      .then((res) => {
        setTrack(res as TrackDto);
        setPlaying(true);
      });
  };

  const pause = () => {
    setPlaying(false);
  };

  const resume = () => {
    setPlaying(true);
  };

  const goToNext = () => {
    if (queue.length === 0) {
      throw new Error("State desync.");
    }

    if (track) {
      setHistory([...history, track]);
    }

    const nextTrack = queue.pop()!;
    play(nextTrack.id);
  };

  const goToPrevious = () => {
    if (history.length === 0) {
      throw new Error("State desync.");
    }

    if (track) {
      setQueue([...queue, track]);
    }

    const nextTrack = history.pop()!;
    play(nextTrack.id);
  };

  const hasNext = queue.length > 0;
  const hasPrevious = queue.length > 0;

  return (
    <PlayerContext.Provider
      value={{
        play,
        pause,
        resume,
        goToNext,
        goToPrevious,
        track,
        history,
        queue,
        playing,
        hasNext,
        hasPrevious,
      }}
    >
      {props.children}
    </PlayerContext.Provider>
  );
}

"use client";
import { getAlbum } from "@/libs/albums";
import { getTrack } from "@/libs/tracks";
import { AlbumDto } from "@/types/album";
import { TrackDto } from "@/types/track";
import { ReactNode, createContext, useState } from "react";

type PlayerContextValue = {
  playing: boolean;
  track: TrackDto | null;
  album: AlbumDto | null;
  queue: TrackDto[];
  history: TrackDto[];
  hasNext: boolean;
  hasPrevious: boolean;
  volume: number;
  muted: boolean;
  play: (trackId: number) => void;
  pause: () => void;
  resume: () => void;
  goToNext: () => void;
  goToPrevious: () => void;
  setVolume: (value: number) => void;
  toggleMute: () => void;
};

export const PlayerContext = createContext<PlayerContextValue>({} as any);

export default function PlayerProvider(props: { children: ReactNode }) {
  const [playing, setPlaying] = useState(false);
  const [track, setTrack] = useState<TrackDto | null>(null);
  const [album, setAlbum] = useState<AlbumDto | null>(null);
  const [queue, setQueue] = useState<TrackDto[]>([]);
  const [history, setHistory] = useState<TrackDto[]>([]);
  const [_volume, _setVolume] = useState(50);
  const [muted, setMuted] = useState(false);

  const play = (trackId: number) => {
    getTrack(trackId).then((res) => {
      setTrack(res);
      getAlbum(res.albumId).then((res) => {
        setAlbum(res);
        setPlaying(true);
      });
    });
  };

  const pause = () => {
    setPlaying(false);
  };

  const resume = () => {
    setPlaying(true);
  };

  const goToNext = () => {
    if (!hasNext) {
      return;
    }

    if (track) {
      setHistory([...history, track]);
    }

    const nextTrack = queue.pop()!;
    play(nextTrack.id);
  };

  const goToPrevious = () => {
    if (!hasPrevious) {
      return;
    }

    if (track) {
      setQueue([...queue, track]);
    }

    const nextTrack = history.pop()!;
    play(nextTrack.id);
  };

  const hasNext = queue.length > 0;
  const hasPrevious = queue.length > 0;

  const volume = muted ? 0 : _volume;

  const setVolume = (value: number) => {
    _setVolume(value);
    setMuted(false);
  };

  const toggleMute = () => {
    setMuted(!muted);
  };

  return (
    <PlayerContext.Provider
      value={{
        playing,
        track,
        album,
        queue,
        history,
        hasNext,
        hasPrevious,
        play,
        pause,
        resume,
        goToNext,
        goToPrevious,
        volume,
        setVolume,
        muted,
        toggleMute,
      }}
    >
      {props.children}
    </PlayerContext.Provider>
  );
}

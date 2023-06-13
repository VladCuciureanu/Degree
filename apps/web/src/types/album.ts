import { ArtistDto } from "./artist";

export type AlbumDto = {
  id: number;
  name: string;
  imageUrl?: string;
  type: string;
  artist: ArtistDto;
};

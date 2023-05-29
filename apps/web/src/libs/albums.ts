import { AlbumDto } from "@/types/album";
import { PaginatedList } from "@/types/common";
import { TrackDto } from "@/types/track";
import { fetchUrl } from "@/utils/fetch-url";

export function getAlbums(): Promise<PaginatedList<AlbumDto>> {
  return fetchUrl(`${process.env.NEXT_PUBLIC_API_URL}/api/albums`).then((res) =>
    res.json()
  );
}

export function getAlbum(id: number): Promise<AlbumDto> {
  return fetchUrl(`${process.env.NEXT_PUBLIC_API_URL}/api/albums/${id}`).then(
    (res) => res.json()
  );
}

export function getAlbumTracks(id: number): Promise<TrackDto[]> {
  return fetchUrl(
    `${process.env.NEXT_PUBLIC_API_URL}/api/albums/${id}/tracks`
  ).then((res) => res.json());
}

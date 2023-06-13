import { AlbumDto } from "@/types/album";
import { ArtistDto } from "@/types/artist";
import { PaginatedList } from "@/types/common";
import { fetchUrl } from "@/utils/fetch-url";

export function getArtists(): Promise<PaginatedList<ArtistDto>> {
  return fetchUrl(`${process.env.NEXT_PUBLIC_API_URL}/api/artists`).then(
    (res) => res.json()
  );
}

export function getArtist(id: number): Promise<ArtistDto> {
  return fetchUrl(`${process.env.NEXT_PUBLIC_API_URL}/api/artists/${id}`).then(
    (res) => res.json()
  );
}

export function getArtistAlbums(id: number): Promise<AlbumDto[]> {
  return fetchUrl(
    `${process.env.NEXT_PUBLIC_API_URL}/api/artists/${id}/albums`
  ).then((res) => res.json());
}

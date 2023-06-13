import { ArtistDto } from "@/types/artist";
import { PaginatedList } from "@/types/common";
import { TrackDto } from "@/types/track";
import { fetchUrl } from "@/utils/fetch-url";

export function getTracks(): Promise<PaginatedList<TrackDto>> {
  return fetchUrl(`${process.env.NEXT_PUBLIC_API_URL}/api/tracks`).then((res) =>
    res.json()
  );
}

export function getTrack(id: number): Promise<TrackDto> {
  return fetchUrl(`${process.env.NEXT_PUBLIC_API_URL}/api/tracks/${id}`).then(
    (res) => res.json()
  );
}

export function getTrackArtists(id: number): Promise<ArtistDto[]> {
  return fetchUrl(
    `${process.env.NEXT_PUBLIC_API_URL}/api/tracks/${id}/artists`
  ).then((res) => res.json());
}

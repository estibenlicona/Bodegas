export interface IApiResponse<T> {
  message: String;
  count: number;
  body: T[];
}

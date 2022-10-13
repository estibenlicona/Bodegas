export interface IFilter {
  column: string | undefined,
  type: string,
  value: string | number | boolean | undefined,
  start: string | undefined,
  end: string | undefined
}

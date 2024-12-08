import { Muly as TMuly } from "../api/muly/Muly";

export const MULY_TITLE_FIELD = "aaa";

export const MulyTitle = (record: TMuly): string => {
  return record.aaa?.toString() || String(record.id);
};

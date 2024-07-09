import { Muly as TMuly } from "../api/muly/Muly";

export const MULY_TITLE_FIELD = "fld1";

export const MulyTitle = (record: TMuly): string => {
  return record.fld1?.toString() || String(record.id);
};

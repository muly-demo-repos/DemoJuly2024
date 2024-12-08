import { Yuval as TYuval } from "../api/yuval/Yuval";

export const YUVAL_TITLE_FIELD = "ald1";

export const YuvalTitle = (record: TYuval): string => {
  return record.ald1?.toString() || String(record.id);
};

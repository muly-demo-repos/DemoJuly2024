import * as React from "react";
import { List, Datagrid, ListProps, TextField, DateField } from "react-admin";
import Pagination from "../Components/Pagination";

export const YuvalList = (props: ListProps): React.ReactElement => {
  return (
    <List
      {...props}
      bulkActionButtons={false}
      title={"Yuvals"}
      perPage={50}
      pagination={<Pagination />}
    >
      <Datagrid rowClick="show">
        <TextField label="ald1" source="ald1" />
        <DateField source="createdAt" label="Created At" />
        <TextField label="eld1" source="eld1" />
        <TextField label="eld2" source="eld2" />
        <TextField label="eld2b" source="eld2b" />
        <TextField label="fld1" source="fld1" />
        <TextField label="ID" source="id" />
        <DateField source="updatedAt" label="Updated At" />
      </Datagrid>
    </List>
  );
};

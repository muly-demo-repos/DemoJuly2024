import * as React from "react";
import { List, Datagrid, ListProps, TextField, DateField } from "react-admin";
import Pagination from "../Components/Pagination";

export const MulyList = (props: ListProps): React.ReactElement => {
  return (
    <List
      {...props}
      bulkActionButtons={false}
      title={"Mulies"}
      perPage={50}
      pagination={<Pagination />}
    >
      <Datagrid rowClick="show">
        <TextField label="aaa" source="aaa" />
        <TextField label="abc" source="abc" />
        <TextField label="beck" source="beck" />
        <DateField source="createdAt" label="Created At" />
        <TextField label="fox" source="fox" />
        <TextField label="ID" source="id" />
        <TextField label="niver" source="niver" />
        <TextField label="park" source="park" />
        <DateField source="updatedAt" label="Updated At" />
        <TextField label="zisIsFirst" source="zisIsFirst" />
      </Datagrid>
    </List>
  );
};

import * as React from "react";
import {
  List,
  Datagrid,
  ListProps,
  TextField,
  DateField,
  ReferenceField,
} from "react-admin";
import Pagination from "../Components/Pagination";
import { SALESPERSON_TITLE_FIELD } from "../salesperson/SalespersonTitle";

export const SaleList = (props: ListProps): React.ReactElement => {
  return (
    <List
      {...props}
      bulkActionButtons={false}
      title={"Sales"}
      perPage={50}
      pagination={<Pagination />}
    >
      <Datagrid rowClick="show">
        <TextField label="ID" source="id" />
        <DateField source="createdAt" label="Created At" />
        <DateField source="updatedAt" label="Updated At" />
        <TextField label="date" source="date" />
        <TextField label="amount" source="amount" />
        <TextField label="client" source="client" />
        <ReferenceField
          label="salesperson"
          source="salesperson.id"
          reference="Salesperson"
        >
          <TextField source={SALESPERSON_TITLE_FIELD} />
        </ReferenceField>
        <TextField label="vehicle" source="vehicle" />
      </Datagrid>
    </List>
  );
};

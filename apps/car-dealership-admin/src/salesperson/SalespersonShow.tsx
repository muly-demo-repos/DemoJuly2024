import * as React from "react";

import {
  Show,
  SimpleShowLayout,
  ShowProps,
  TextField,
  DateField,
  ReferenceManyField,
  Datagrid,
  ReferenceField,
} from "react-admin";

import { SALESPERSON_TITLE_FIELD } from "./SalespersonTitle";

export const SalespersonShow = (props: ShowProps): React.ReactElement => {
  return (
    <Show {...props}>
      <SimpleShowLayout>
        <TextField label="ID" source="id" />
        <DateField source="createdAt" label="Created At" />
        <DateField source="updatedAt" label="Updated At" />
        <TextField label="lastName" source="lastName" />
        <TextField label="phone" source="phone" />
        <TextField label="firstName" source="firstName" />
        <TextField label="email" source="email" />
        <ReferenceManyField
          reference="Sale"
          target="salespersonId"
          label="Sales"
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
        </ReferenceManyField>
      </SimpleShowLayout>
    </Show>
  );
};

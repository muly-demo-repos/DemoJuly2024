import * as React from "react";
import {
  Show,
  SimpleShowLayout,
  ShowProps,
  TextField,
  DateField,
} from "react-admin";

export const MulyShow = (props: ShowProps): React.ReactElement => {
  return (
    <Show {...props}>
      <SimpleShowLayout>
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
      </SimpleShowLayout>
    </Show>
  );
};

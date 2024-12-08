import * as React from "react";
import {
  Show,
  SimpleShowLayout,
  ShowProps,
  TextField,
  DateField,
} from "react-admin";

export const YuvalShow = (props: ShowProps): React.ReactElement => {
  return (
    <Show {...props}>
      <SimpleShowLayout>
        <TextField label="ald1" source="ald1" />
        <DateField source="createdAt" label="Created At" />
        <TextField label="eld1" source="eld1" />
        <TextField label="eld2" source="eld2" />
        <TextField label="eld2b" source="eld2b" />
        <TextField label="fld1" source="fld1" />
        <TextField label="ID" source="id" />
        <DateField source="updatedAt" label="Updated At" />
      </SimpleShowLayout>
    </Show>
  );
};

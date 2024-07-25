/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { InputType, Field } from "@nestjs/graphql";
import { ApiProperty } from "@nestjs/swagger";
import { IsDate, IsOptional, IsEnum, ValidateNested } from "class-validator";
import { Type } from "class-transformer";
import { EnumOrderStatus } from "./EnumOrderStatus";
import { CustomerWhereUniqueInput } from "../../customer/base/CustomerWhereUniqueInput";
import { OrderItemUpdateManyWithoutOrdersInput } from "./OrderItemUpdateManyWithoutOrdersInput";

@InputType()
class OrderUpdateInput {
  @ApiProperty({
    required: false,
  })
  @IsDate()
  @Type(() => Date)
  @IsOptional()
  @Field(() => Date, {
    nullable: true,
  })
  date?: Date | null;

  @ApiProperty({
    required: false,
    enum: EnumOrderStatus,
  })
  @IsEnum(EnumOrderStatus)
  @IsOptional()
  @Field(() => EnumOrderStatus, {
    nullable: true,
  })
  status?: "Option1" | null;

  @ApiProperty({
    required: false,
    type: () => CustomerWhereUniqueInput,
  })
  @ValidateNested()
  @Type(() => CustomerWhereUniqueInput)
  @IsOptional()
  @Field(() => CustomerWhereUniqueInput, {
    nullable: true,
  })
  customer?: CustomerWhereUniqueInput | null;

  @ApiProperty({
    required: false,
    type: () => OrderItemUpdateManyWithoutOrdersInput,
  })
  @ValidateNested()
  @Type(() => OrderItemUpdateManyWithoutOrdersInput)
  @IsOptional()
  @Field(() => OrderItemUpdateManyWithoutOrdersInput, {
    nullable: true,
  })
  orderItems?: OrderItemUpdateManyWithoutOrdersInput;
}

export { OrderUpdateInput as OrderUpdateInput };

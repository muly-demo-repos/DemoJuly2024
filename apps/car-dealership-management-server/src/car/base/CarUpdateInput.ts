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
import {
  IsString,
  MaxLength,
  IsOptional,
  IsInt,
  Min,
  Max,
  ValidateNested,
  IsNumber,
} from "class-validator";
import { SaleUpdateManyWithoutCarsInput } from "./SaleUpdateManyWithoutCarsInput";
import { Type } from "class-transformer";

@InputType()
class CarUpdateInput {
  @ApiProperty({
    required: false,
    type: String,
  })
  @IsString()
  @MaxLength(1000)
  @IsOptional()
  @Field(() => String, {
    nullable: true,
  })
  make?: string | null;

  @ApiProperty({
    required: false,
    type: Number,
  })
  @IsInt()
  @Min(-999999999)
  @Max(999999999)
  @IsOptional()
  @Field(() => Number, {
    nullable: true,
  })
  year?: number | null;

  @ApiProperty({
    required: false,
    type: String,
  })
  @IsString()
  @MaxLength(1000)
  @IsOptional()
  @Field(() => String, {
    nullable: true,
  })
  model?: string;

  @ApiProperty({
    required: false,
    type: () => SaleUpdateManyWithoutCarsInput,
  })
  @ValidateNested()
  @Type(() => SaleUpdateManyWithoutCarsInput)
  @IsOptional()
  @Field(() => SaleUpdateManyWithoutCarsInput, {
    nullable: true,
  })
  sales?: SaleUpdateManyWithoutCarsInput;

  @ApiProperty({
    required: false,
    type: Number,
  })
  @IsNumber()
  @Min(-999999999)
  @Max(999999999)
  @IsOptional()
  @Field(() => Number, {
    nullable: true,
  })
  price?: number | null;

  @ApiProperty({
    required: false,
    type: String,
  })
  @IsString()
  @MaxLength(20)
  @IsOptional()
  @Field(() => String, {
    nullable: true,
  })
  licenseNumber?: string | null;
}

export { CarUpdateInput as CarUpdateInput };

export class SaveLocationForOrderRequestDto {
  public cityId: string;
  public districtId: string;
  public customerId: string;
  public detail: string;

  constructor(
    cityId: string,
    districtId: string,
    customerId: string,
    detail: string
  ) {
    this.cityId = cityId;
    this.districtId = districtId;
    this.customerId = customerId;
    this.detail = detail;
  }
}
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NearbyServicesComponent } from './nearby-services.component';

describe('NearbyServicesComponent', () => {
  let component: NearbyServicesComponent;
  let fixture: ComponentFixture<NearbyServicesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NearbyServicesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NearbyServicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

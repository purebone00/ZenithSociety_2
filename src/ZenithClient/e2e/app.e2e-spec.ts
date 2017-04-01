import { ZenithClientPage } from './app.po';

describe('zenith-client App', () => {
  let page: ZenithClientPage;

  beforeEach(() => {
    page = new ZenithClientPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
